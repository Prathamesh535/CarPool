import { LogInActionType } from "../Actions/LogInActionType"
import { ActionType } from "../Action-Types/ActionType"
interface LogInState{
    loginName:string,
    loginPassword:string
}
const intialstate:LogInState = {
    loginName:"",
    loginPassword:""
}

export const LogInReducer=(state:LogInState=intialstate,action:LogInActionType)=>{
    switch (action.type) {
        case ActionType.LOGINNAME:
            return{
                ...state,
                loginName:action.payload
            }
        case ActionType.LOGINPASSWORD:
            return{
                ...state,
                loginPassword:action.payload
            }
        default:
            return state;
    }
}