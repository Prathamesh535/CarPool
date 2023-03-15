interface OfferRideFrom {
    type: string,
    payload: string
}
interface OfferRideTo {
    type: string,
    payload: string
}
interface OfferRideDate{
    type:string,
    payload:string
}

export type OfferRideActionType = OfferRideTo | OfferRideFrom | OfferRideDate