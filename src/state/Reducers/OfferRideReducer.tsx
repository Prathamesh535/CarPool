import { ActionType } from "../Action-Types/ActionType";
import { OfferRideActionType } from "../Actions/OfferRideActionType";
interface OfferRideState {
    offerRideFrom: string,
    offerRideTo: string,
    offerRideDate: string
}
const intialstate: OfferRideState = {
    offerRideFrom: "",
    offerRideTo: "",
    offerRideDate: ""
}
export const OfferRideReducer = (state: OfferRideState = intialstate, action: OfferRideActionType) => {
    switch (action.type) {
        case ActionType.OFFERRIDEFROM:
            return {
                ...state,
                offerRideFrom: action.payload
            }
        case ActionType.OFFERRIDETO:
            return {
                ...state,
                offerRideTo: action.payload
            }
        case ActionType.OFFERRIDEDATE:
            return {
                ...state,
                offerRideDate: action.payload
            }
        default:
            return state;
    }
}