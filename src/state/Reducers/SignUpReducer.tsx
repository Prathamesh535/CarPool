import { ActionType } from "../Action-Types/ActionType"
import {signupActionType} from "../Actions/signupActionType"
interface State {
    name: string,
    password: string,
    confirmPassword: string
}
const intialstate: State = {
    name: "",
    password: "",
    confirmPassword: ""
}

export const SignUpReducer = (state: State = intialstate, action: signupActionType) => {
    switch (action.type) {
        case ActionType.SIGNUPNAME:
            return {
                ...state,
                name: action.payload
            };
        case ActionType.SIGNUPPASSWORD:
            return {
                ...state,
                password: action.payload
            }
        case ActionType.SIGNUPCONFIRMPASSWORD:
            return {
                ...state,
                confirmPassword: action.payload
            }
        default:
            return state;
    }
}

