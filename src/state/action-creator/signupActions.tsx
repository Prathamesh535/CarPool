import { Dispatch } from "react"
import { ActionType } from "../Action-Types/ActionType"
import { signupActionType } from "../Actions/signupActionType"

export const signUpName = (value: string) => {
    return (dispatch: Dispatch<signupActionType>) => (
        dispatch({
            type: ActionType.SIGNUPNAME,
            payload: value
        })
    )
}
export const signUpPassword = (value: string) => {
    return (dispatch: Dispatch<signupActionType>) => (
        dispatch({
            type: ActionType.SIGNUPPASSWORD,
            payload: value
        })
    )
}
export const signUpConfirmPassword = (value: string) => {
    return (dispatch: Dispatch<signupActionType>) => (
        dispatch({
            type: ActionType.SIGNUPCONFIRMPASSWORD,
            payload: value
        })
    )
}


