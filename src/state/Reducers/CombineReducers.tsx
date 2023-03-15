import { combineReducers } from "redux";
import { SignUpReducer } from "./signupReducer";
import { LogInReducer } from "./LogInReducer";
import { OfferRideReducer } from "./offerRideReducer";
export const reducers = combineReducers({
    SignUp:SignUpReducer,
    Login:LogInReducer,
    OfferRide:OfferRideReducer
})

export type RootState = ReturnType<typeof reducers>