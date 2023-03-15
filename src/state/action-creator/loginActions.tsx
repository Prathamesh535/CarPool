import { Dispatch } from "react"
import { ActionType } from "../Action-Types/ActionType"
import { loginActionType } from "../Actions/LogInActionType"

export const loginName = (value:string) => {
    return (dispatch:Dispatch<loginActionType>)=>{
        dispatch({
            type:ActionType.LOGINNAME,
            payload:value
        })
    }
} 
export const loginPassword = (value:string) => {
    return (dispatch:Dispatch<loginActionType>)=>{
        dispatch({
            type:ActionType.LOGINPASSWORD,
            payload:value
        })
    }
} 