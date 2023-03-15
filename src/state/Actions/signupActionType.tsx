import { ActionType } from "../Action-Types/ActionType"
interface SignUpName {
    type: ActionType.SIGNUPNAME,
    payload: string
}
interface signUpPassword {
    type: ActionType.SIGNUPPASSWORD,
    payload: string
}
interface signUpConfirmPassword {
    type: ActionType.SIGNUPCONFIRMPASSWORD,
    payload: string
}
export type signupActionType = SignUpName | signUpPassword | signUpConfirmPassword