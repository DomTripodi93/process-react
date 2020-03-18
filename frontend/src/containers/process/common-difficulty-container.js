import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { fetchCommonDifficultiesByStep } from '../../reducers/process/common-difficulty/common-difficulty.actions';
import CommonDifficultyNew from '../../components/process/common-difficulty/common-difficulty-new';
import CommonDifficulties from '../../components/process/common-difficulty/common-difficulties';


const CommonDifficultyContainer = (props) => {
    const [addMode, setAddMode] = useState(false);
    const fetchCommonDifficulties = props.fetchCommonDifficulties;
    const deptName = props.deptName;
    const objectiveName = props.objectiveName;

    useEffect(()=>{
        if (
            deptName !== undefined && 
            objectiveName !== undefined && 
            deptName !== ""
        ){
            fetchCommonDifficulties(deptName, objectiveName);
        }
    },[fetchCommonDifficulties, deptName, objectiveName]);


    const showCommonDifficultyForm = () =>{
        setAddMode(!addMode)
    }

    return(
        <div>
            <h3 className='centered'>Common Difficulties</h3>
            <div className="grid100">
                <CommonDifficultyNew
                    deptName={deptName}
                    objectiveName={objectiveName}
                    addMode={addMode}
                    action={showCommonDifficultyForm}/>
            </div>
            <br />
            {props.commonDifficultys ?
                <CommonDifficulties 
                    deptName={deptName}
                    objectiveName={objectiveName}
                    action={showCommonDifficultyForm} 
                    commonDifficulties={props.commonDifficulties}/>
            :
                null
            }
        </div>
    )
}

const mapDispatchToProps = dispatch => { 
    return {
        fetchCommonDifficulties: (deptName, objectiveName, stepNumber) => dispatch(fetchCommonDifficultiesByStep(deptName, objectiveName, stepNumber))
    }
}

const mapStateToProps = state => ({
    commonDifficulties: state.commonDifficulty.commonDifficulties
});

export default connect(mapStateToProps, mapDispatchToProps)(CommonDifficultyContainer);