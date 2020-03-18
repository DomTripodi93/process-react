import rootHttp from '../../root-http';
import CommonDifficultyActionTypes from './common-difficulty.types';
import helpers from '../../../shared/helpers';
import store from '../../store';


const http = new rootHttp();
const helper = new helpers();

export function fetchSingleCommonDifficulty(id){
    return dispatch => {
        http.fetchById(id)
            .then((commonDifficulty) => {
                dispatch(setSingleCommonDifficulty(commonDifficulty.data));
            });
    }  
}
//Gets specific commonDifficulty by name

export function fetchCommonDifficultiesByStep(deptName, objectiveName, stepNumber){
    return dispatch => {
        http.fetchAll("commonDifficulty/byStep/" + deptName + "&" + objectiveName + "&" + stepNumber)
            .then((commonDifficulties) => {
                dispatch(setCommonDifficulties(commonDifficulties));
            });
    }
}
//Gets all commonDifficulties for a specific department

export function addCommonDifficulty(commonDifficulty, callback){
    commonDifficulty = prepCommonDifficultyValues(commonDifficulty);
    return dispatch =>{
        http.addItem("commonDifficulty", commonDifficulty)
            .then(addedCommonDifficulty =>{
                dispatch(addCommonDifficultyToState(addedCommonDifficulty.data));
                callback();
            });
    }
}
//Posts new commonDifficulty to API

export function updateCommonDifficulty(commonDifficulty, callback){
    commonDifficulty = prepCommonDifficultyValues(commonDifficulty);
    return dispatch =>{
        http.updateItemById("commonDifficulty", commonDifficulty, commonDifficulty.id)
            .then(() =>{
                dispatch(updateCommonDifficultiesInState(commonDifficulty));
                callback();
            });
    }
}
//Updates commonDifficulty in database

export function updateSingleCommonDifficulty(commonDifficulty, callback){
    commonDifficulty = prepCommonDifficultyValues(commonDifficulty);
    return dispatch =>{
        http.updateItem("commonDifficulty", commonDifficulty, commonDifficulty.deptName + "&" + commonDifficulty.objectiveName+ "&" + commonDifficulty.commonDifficultyNumber)
            .then(() =>{
                if (Object.keys(store.getState().commonDifficulty.commonDifficulties).length > 0){
                    dispatch(updateCommonDifficultiesInState(commonDifficulty));
                }
                dispatch(setSingleCommonDifficulty(commonDifficulty));
                callback();
            });
    }
}
//Updates objective in database

export function deleteCommonDifficulty(id){
    return dispatch =>{
        http.deleteItemById("commonDifficulty", id)
            .then(()=>{
                dispatch(deleteCommonDifficultyFromState(id));
            });
    }
}
//Deletes selected commonDifficulty

export function addCommonDifficultyToState(commonDifficulty){
    return {
        type: CommonDifficultyActionTypes.ADD_COMMON_DIFFICULTY,
        payload: commonDifficulty
    }
}
//Adds new commonDifficulty from post to state

export function setCommonDifficulties(commonDifficulties){
    return {
        type: CommonDifficultyActionTypes.SET_COMMON_DIFFICULTIES,
        payload: commonDifficulties
    }
}
//Sets all commonDifficulties in state

export function setSingleCommonDifficulty(commonDifficulty){
    return {
        type: CommonDifficultyActionTypes.SET_SINGLE_COMMON_DIFFICULTY,
        payload: commonDifficulty
    }
}
//Sets selected commonDifficulty in state

export function updateCommonDifficultiesInState(commonDifficulty){
    return {
        type: CommonDifficultyActionTypes.UPDATE_COMMON_DIFFICULTIES,
        payload: commonDifficulty
    }
}
//Updates function for commonDifficulty

export function deleteCommonDifficultyFromState(commonDifficultyNumber){
    return {
        type: CommonDifficultyActionTypes.DELETE_COMMON_DIFFICULTY,
        payload: commonDifficultyNumber
    }
}
//Deletes selected commonDifficulty

function prepCommonDifficultyValues(commonDifficulty){
    commonDifficulty.difficulty = helper.capitalizeAll(commonDifficulty.difficulty);
    if (commonDifficulty.cause){
        commonDifficulty.cause = helper.capitalize(commonDifficulty.cause);
    }
    if (commonDifficulty.solution){
        commonDifficulty.solution = helper.capitalize(commonDifficulty.solution);
    }

    return commonDifficulty;
}