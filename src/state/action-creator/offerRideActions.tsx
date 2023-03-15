import { Dispatch } from "react"
import { ActionType } from "../Action-Types/ActionType"
import { OfferRideActionType } from "../Actions/offerRideActionType"

export const offerARideFrom = (value: string) => {
    return (dispatch: Dispatch<OfferRideActionType>) => (
        dispatch({
            type: ActionType.OFFERRIDEFROM,
            payload: value
        })
    )
}
export const offerARideTo = (value: string) => {
    return (dispatch: Dispatch<OfferRideActionType>) => (
        dispatch({
            type: ActionType.OFFERRIDETO,
            payload: value
        })
    )
}

export const offerARideDate = (value: string) => {
    let date = value.substring(8, 10) + "/" + value.substring(5, 7) + "/" + value.substring(0, 4)
    return (dispatch: Dispatch<OfferRideActionType>) => {
        dispatch({
            type: ActionType.OFFERRIDEDATE,
            payload: date
        })
    }
}