import React, { useState, useEffect } from 'react';
import CalendarHelper from '../../shared/calendar-helper';
import { fetchSchedulesByEmployee, fetchSchedulesByDate, resetSchedules } from '../../reducers/schedule/schedule/schedule.actions';
import { connect } from 'react-redux';
import ScheduleDay from '../../components/schedule/schedule/schedule-day';
import ScheduleNew from '../../components/schedule/schedule/schedule-new';
import { fetchDepartments } from '../../reducers/process/department/department.actions';
import { fetchObjectivesByDepartment } from '../../reducers/process/objective/objective.actions';
import { fetchEmployeesForMap } from '../../reducers/schedule/employee/employee.actions';


const ScheduleDayContainer = props => {
    const [addMode, setAddMode] = useState(false);
    const helper = new CalendarHelper();
    const employeeId = props.match.params.employeeId;
    const month = +props.match.params.month;
    const day = +props.match.params.day;
    const year = +props.match.params.year;
    const lastDay = helper.checkDays(year, month);
    
    const departments = props.departments;
    const deptCalled = props.deptCalled;
    const objectives = props.objectives;
    const objCalled = props.objCalled;
    const fetchAllDepartments = props.fetchDepartments;
    const fetchObjectivesForDepartment = props.fetchObjectivesByDepartment;

    useEffect(()=>{
        if (!deptCalled){
            fetchAllDepartments();
        } else if (!objCalled){
            departments.forEach(dept =>{
                fetchObjectivesForDepartment(dept.deptName);
            })
        }
    },[
        departments, 
        objectives,
        fetchAllDepartments, 
        fetchObjectivesForDepartment
    ])


    const scheduledTasks = props.scheduledTasks;
    const fetchSchedulesForDate = props.fetchSchedulesByDate;
    const fetchSchedulesForEmployee = props.fetchSchedulesByEmployee;
    const scheduledTasksCalled = props.scheduledTasksCalled;
    const resetAllSchedules = props.resetSchedules;

    useEffect(()=>{
        if (!scheduledTasksCalled){
            if (employeeId){
                fetchSchedulesForEmployee(employeeId, month, day, year);
            } else {
                fetchSchedulesForDate(month, day, year);
            }
        }
    },[
        scheduledTasks,
        scheduledTasksCalled,
        fetchSchedulesForEmployee,
        fetchSchedulesForDate,
        employeeId,
        month,
        day,
        year
    ])

    const employeeMap = props.employeeMap;
    const employeeCalled = props.employeeCalled;
    const fetchEmployees = props.fetchEmployees;


    useEffect(()=>{
        if (!employeeCalled){
            fetchEmployees();
        }
        return 
    },[
        fetchEmployees,
        employeeMap
    ]);


    useEffect(()=>{
        return ()=>{resetAllSchedules()}
    },[resetAllSchedules])


    const changeDay = (movement) => {
        let route = ""
        if (movement === 'next'){
            if (day < lastDay){
                route = month + "/" + (day + 1) + "/" + year;
            } else {
                if (month < 12){
                    route = (month + 1) + "/1/" + year;
                } else {
                    route = "1/1/" + (year + 1);
                }
            }
        } else if (movement === 'last') {
            if (day > 1){
                route = month + "/" + (day - 1) + "/" + year;
            } else {
                if (month > 1){
                    let newDay = helper.checkDays(year, month-1);
                    route = (month - 1) + "/" + newDay + "/" + year;
                } else {
                    route = "12/31/" + (year-1);
                }
            }
        }
        if (employeeId){
            route = employeeId + "/" + route;
        }
        props.resetSchedules();
        props.history.push("/day/" + route);
    }


    const showScheduleForm = () =>{
        setAddMode(!addMode);
    }


    return(
        <div>
            <ScheduleNew 
                addMode={addMode}
                action={showScheduleForm}
                objectives={props.objectives}
                employeeId={employeeId}
                year={year}
                month={month}
                day={day}
                employeeMap={employeeMap}/>
            {employeeMap[employeeId] ?
                <h3 className="centered">{employeeMap[employeeId]}'s Schedule for {month}-{day}-{year}</h3>
            :
                <h3 className="centered">Schedule for {month}-{day}-{year}</h3>
            }
            <ScheduleDay 
                scheduledTasks={props.scheduledTasks} 
                action={changeDay}
                employeeId={employeeId}
                objectives={props.objectives}
                year={year}
                month={month}
                day={day}
                employeeMap={employeeMap}/>
        </div>
    )
}

const mapDispatchToProps = dispatch => { 
    return {
        fetchSchedulesByEmployee: (employeeId, month, day, year) => dispatch(fetchSchedulesByEmployee(employeeId, month, day, year)),
        fetchSchedulesByDate: (month, day, year) => dispatch(fetchSchedulesByDate(month, day, year)),
        fetchDepartments: () => dispatch(fetchDepartments()),
        fetchObjectivesByDepartment: (deptName) => dispatch(fetchObjectivesByDepartment(deptName)),
        fetchEmployees: () => dispatch(fetchEmployeesForMap()),
        resetSchedules: () => dispatch(resetSchedules())
    }
}

const mapStateToProps = state => ({
    scheduledTasks: state.schedule.scheduledTasks,
    scheduledTasksCalled: state.schedule.scheduledTasksCalled,
    departments: state.department.departments,
    deptCalled: state.department.called,
    objectives: state.objective.objectives,
    objCalled: state.objective.called,
    employeeMap: state.employee.employeeMap,
    employeeCalled: state.employee.called
});

export default connect(mapStateToProps, mapDispatchToProps)(ScheduleDayContainer);