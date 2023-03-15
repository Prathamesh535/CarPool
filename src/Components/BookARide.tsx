import Logo from '../Images/logo.png';
import JohnCena from '../Images/JohnCena.jpeg'
import Rides from '../Images/rides.png'
import { useEffect, useState } from 'react';
interface Details {
    offeringId: number,
    locationName: string,
    from: string,
    to: string,
    offerDate: string,
    price: number,
    stopId: number,
    availableSeats: number,
    userName: string,
    stopNumber: number,
    offerTiming: string,
    accountId: number
}
export default function BookARide() {
    const [offeringRideDetails, setOfferingRideDetails] = useState<Array<Details>>([])
    const [offerCard, setOfferCard] = useState<Array<any>>([])
    const [bookFrom, setBookFrom] = useState('')
    const [bookTo, setBookTo] = useState('')
    const [bookDate, setBookDate] = useState('')
    const [bookTime, setBookTime] = useState('')
    const [purpleBackground1, setPurpleBackground1] = useState({})
    const [purpleBackground2, setPurpleBackground2] = useState({})
    const [purpleBackground3, setPurpleBackground3] = useState({})
    const [purpleBackground4, setPurpleBackground4] = useState({})
    const [purpleBackground5, setPurpleBackground5] = useState({})
    const bookARideFrom = (event: React.ChangeEvent<HTMLInputElement>) => {
        setBookFrom(event.target.value)
    }
    const bookARideTo = (event: React.ChangeEvent<HTMLInputElement>) => {
        setBookTo(event.target.value)
    }
    const bookARideDate = (event: React.ChangeEvent<HTMLInputElement>) => {
        let date = event.target.value.substring(8, 10) + "/" + event.target.value.substring(5, 7) + "/" + event.target.value.substring(0, 4)
        setBookDate(date)
    }
    const timing = (time: string) => {
        setBookTime(time)
        switch (time) {
            case '5am-9am':
                setPurpleBackground1({ backgroundColor: "#9319ff", color: "white" })
                setPurpleBackground2({ backgroundColor: "white", color: "black" })
                setPurpleBackground3({ backgroundColor: "white", color: "black" })
                setPurpleBackground4({ backgroundColor: "white", color: "black" })
                setPurpleBackground5({ backgroundColor: "white", color: "black" })
                break;
            case '9am-12pm':
                setPurpleBackground2({ backgroundColor: "#9319ff", color: "white" })
                setPurpleBackground1({ backgroundColor: "white", color: "black" })
                setPurpleBackground3({ backgroundColor: "white", color: "black" })
                setPurpleBackground4({ backgroundColor: "white", color: "black" })
                setPurpleBackground5({ backgroundColor: "white", color: "black" })
                break;
            case '12pm-3pm':
                setPurpleBackground3({ backgroundColor: "#9319ff", color: "white" })
                setPurpleBackground4({ backgroundColor: "white", color: "black" })
                setPurpleBackground5({ backgroundColor: "white", color: "black" })
                setPurpleBackground1({ backgroundColor: "white", color: "black" })
                setPurpleBackground2({ backgroundColor: "white", color: "black" })
                break;
            case '3pm-6pm':
                setPurpleBackground4({ backgroundColor: "#9319ff", color: "white" })
                setPurpleBackground2({ backgroundColor: "white", color: "black" })
                setPurpleBackground3({ backgroundColor: "white", color: "black" })
                setPurpleBackground1({ backgroundColor: "white", color: "black" })
                setPurpleBackground5({ backgroundColor: "white", color: "black" })
                break;
            case '6pm-9pm':
                setPurpleBackground5({ backgroundColor: "#9319ff", color: "white" })
                setPurpleBackground2({ backgroundColor: "white", color: "black" })
                setPurpleBackground3({ backgroundColor: "white", color: "black" })
                setPurpleBackground4({ backgroundColor: "white", color: "black" })
                setPurpleBackground1({ backgroundColor: "white", color: "black" })
                break;
            default:
                break;
        }
    }
    const [bookingFormStyle, setBookingFormStyle] = useState({ display: 'none' })
    const [bookSeatNumber1, setBookSeatNumber1] = useState({})
    const [bookSeatNumber2, setBookSeatNumber2] = useState({})
    const [bookSeatNumber3, setBookSeatNumber3] = useState({})
    const [bookSeats, setBookSeats] = useState<number>()
    const bookSeatNumber = (seat: number) => {
        setBookSeats(seat)
        console.log(offerRideSeatsAvailable)
        if (offerRideSeatsAvailable == 1) {
            setBookSeatNumber1({ backgroundColor: '#9319ff', color: 'white' })
        }
        else if (offerRideSeatsAvailable == 2) {
            switch (seat) {
                case 1:
                    setBookSeatNumber1({ backgroundColor: '#9319ff', color: 'white' })
                    setBookSeatNumber2({ backgroundColor: 'white', color: 'black' })
                    break;
                case 2:
                    setBookSeatNumber1({ backgroundColor: 'white', color: 'black' })
                    setBookSeatNumber2({ backgroundColor: '#9319ff', color: 'white' })
                    break;
            }
        }
        else {
            switch (seat) {
                case 1:
                    setBookSeatNumber1({ backgroundColor: '#9319ff', color: 'white' })
                    setBookSeatNumber2({ backgroundColor: 'white', color: 'black' })
                    setBookSeatNumber3({ backgroundColor: 'white', color: 'black' })
                    break;
                case 2:
                    setBookSeatNumber1({ backgroundColor: 'white', color: 'black' })
                    setBookSeatNumber2({ backgroundColor: '#9319ff', color: 'white' })
                    setBookSeatNumber3({ backgroundColor: 'white', color: 'black' })
                    break;
                case 3:
                    setBookSeatNumber1({ backgroundColor: 'white', color: 'black' })
                    setBookSeatNumber2({ backgroundColor: 'white', color: 'black' })
                    setBookSeatNumber3({ backgroundColor: '#9319ff', color: 'white' })
                    break;
            }
        }
    }
    const [offerRideFrom, setOfferRideFrom] = useState('')
    const [offerRideTo, setOfferRideTo] = useState('')
    const [offerRideSeatsAvailable, setOfferRideSeatsAvailable] = useState<number>()
    const [offerRidePrice, setOfferRidePrice] = useState<number>()
    const [offerRideUserName, setOfferRideUserName] = useState('')
    const [offerRideStopId, setOfferRideStopId] = useState<number>()
    const [offerRideDate, setOfferRideDate] = useState('')
    const [offerRideTiming, setOfferRideTiming] = useState('')
    const bookingForm = (offerRide: Details) => {
        setOfferRideFrom(offerRide.from)
        setOfferRideTo(offerRide.to)
        setOfferRideSeatsAvailable(offerRide.availableSeats)
        setOfferRidePrice(offerRide.price)
        setOfferRideUserName(offerRide.userName)
        setOfferRideStopId(offerRide.offeringId)
        setOfferRideDate(offerRide.offerDate)
        setOfferRideTiming(offerRide.offerTiming)
        if (offerRide.availableSeats == 1) {
            setBookSeatNumber2({ display: "none" })
            setBookSeatNumber3({ display: "none" })
        }
        else if (offerRide.availableSeats == 2) {
            setBookSeatNumber3({ display: "none" })
        }
        else {
            setBookSeatNumber1({ display: "flex" })
            setBookSeatNumber2({ display: "flex" })
            setBookSeatNumber3({ display: "flex" })
        }
        if (bookingFormStyle.display === 'flex') {
            setBookingFormStyle({ display: 'none' })
        }
        else {
            setBookingFormStyle({ display: 'flex' })
        }
    }
    useEffect(() => {
        fetch('https://localhost:7093/api/offeringridedetails', {
        }).then(r => r.json()).then(res => {
            setOfferingRideDetails(res)
        });
    }, [])
    const generateOfferList = async () => {
        let from = bookFrom, to = bookTo;
        let data = []
        setOfferCard([])
        for (let i = 0; i < offeringRideDetails.length; i++) {
            if (offeringRideDetails[i].locationName == from) {
                for (let j = 0; j < offeringRideDetails.length; j++) {
                    if (offeringRideDetails[j].locationName == to && offeringRideDetails[i].offeringId == offeringRideDetails[j].offeringId && offeringRideDetails[i].stopNumber < offeringRideDetails[j].stopNumber && offeringRideDetails[j].offerDate == bookDate && offeringRideDetails[j].offerTiming == bookTime && offeringRideDetails[i].availableSeats>0) {
                        data.push((<div className="offer-card" onClick={() => bookingForm(offeringRideDetails[i])}>
                            <h2>{offeringRideDetails[i].userName}</h2>
                            <div className="offer-ride-display-text-flex">
                                <div className="offer-ride-text-display-1">
                                    <p className='offer-ride-model'>From</p>
                                    <p className='offer-ride-entity'>{offeringRideDetails[i].from}</p>
                                    <p className='offer-ride-model'>Date</p>
                                    <p className='offer-ride-entity'>{offeringRideDetails[i].offerDate}</p>
                                    <p className='offer-ride-model'>Price</p>
                                    <p className='offer-ride-entity'>{offeringRideDetails[i].price}</p>
                                </div>
                                <div className="offer-ride-text-display-2">
                                    <p className='offer-ride-model'>To</p>
                                    <p className='offer-ride-entity'>{offeringRideDetails[i].to}</p>
                                    <p className='offer-ride-model'>Time</p>
                                    <p className='offer-ride-entity'>{offeringRideDetails[i].offerTiming}</p>
                                    <p className='offer-ride-model'>Set Availability</p>
                                    <p className='offer-ride-entity'>{offeringRideDetails[i].availableSeats}</p>
                                </div>
                            </div>
                        </div>))
                        setOfferCard(data)
                    }
                }
            }
        }
    }
    let token = localStorage.getItem("user")
    let user = JSON.parse(localStorage.getItem("userDetails") || '{}')
    const submitBookRide = () => {
        const bookRide = {
            AccountId: user.AccountId,
            OfferBookingId: offerRideStopId,
            From: offerRideFrom,
            To: offerRideTo,
            Charges: offerRidePrice,
            BookingDate: offerRideDate,
            BookTiming: offerRideTiming,
            NumberOfSeatsBooked: bookSeats
        }
        console.log(bookRide)
        fetch('https://localhost:7093/api/bookrides', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(bookRide)
        }).then(r => r.json()).then(res => {
        });
        setBookingFormStyle({ display: "none" })
    }
    return (
        <>
            <div>
                <div className="book-ride-navbar">
                    <img src={Logo} alt="" id='book-ride-ya-logo' />
                    <div className="display-name-and-photo">
                        <h3>{user.UserName}</h3>
                        <img src={JohnCena} alt="" />
                    </div>
                </div>
                <div className="card-flex">
                    <div className="book-ride-card">
                        <h2>Book a Ride</h2>
                        <p className='book-ride-card-heading-2'>We get you the matches asap!</p>
                        <div className='book-ride-form'>
                            <label htmlFor="">From</label>
                            <input type="text" onChange={bookARideFrom} />
                            <label htmlFor="">To</label>
                            <input type="text" onChange={bookARideTo} />
                            <label htmlFor="">Date</label>
                            <input type="date" onChange={bookARideDate} />
                            <label htmlFor="">Time</label>
                            <div className="timing-button">
                                <label htmlFor="">
                                    <input type="checkbox" name="5am-9am" id="" />
                                    <span style={purpleBackground1} onClick={() => timing('5am-9am')}>5am-9am</span>
                                </label>
                                <label htmlFor="">
                                    <input type="checkbox" name="9am-12pm" id="" />
                                    <span style={purpleBackground2} onClick={() => timing('9am-12pm')}>9am-12pm</span>
                                </label>
                                <label htmlFor="">
                                    <input type="checkbox" name="12pm-3pm" id="" />
                                    <span style={purpleBackground3} onClick={() => timing('12pm-3pm')}>12pm-3pm</span>
                                </label>
                                <label htmlFor="">
                                    <input type="checkbox" name="3pm-6pm" id="" />
                                    <span style={purpleBackground4} onClick={() => timing('3pm-6pm')}>3pm-6pm</span>
                                </label>
                                <label htmlFor="">
                                    <input type="checkbox" name="6pm-9pm" id="" />
                                    <span style={purpleBackground5} onClick={() => timing('6pm-9pm')}>6pm- 9pm</span>
                                </label>
                            </div>
                            <button type="submit" className='book-ride-submit-button' onClick={generateOfferList}>Submit</button>
                        </div>
                    </div>
                    <div className="offer-ride-display">
                        <h2 className='your-matches-text'>Your Matches</h2>
                        <div className="offer-ride-display-cards">
                            {offerCard}
                        </div>
                    </div>
                </div>
                <img src={Rides} alt="" className='rides-background-image' />
            </div>
            <div className='pop-up-book-a-ride' style={bookingFormStyle} >
                <h2>{offerRideUserName}</h2>
                <div className="pop-up-book-a-ride-flex">
                    <div className="pop-up-book-a-ride-part-1">
                        <p className='book-ride-card-heading-2'>From</p>
                        <p>{offerRideFrom}</p>
                        <p className='book-ride-card-heading-2'>Book Seats</p>
                        <div className="book-seats">
                            <div className="book-seat-number" style={bookSeatNumber1} onClick={() => bookSeatNumber(1)}>1</div>
                            <div className="book-seat-number" style={bookSeatNumber2} onClick={() => bookSeatNumber(2)}>2</div>
                            <div className="book-seat-number" style={bookSeatNumber3} onClick={() => bookSeatNumber(3)}>3</div>
                        </div>
                    </div>
                    <div className="pop-up-book-a-ride-part-2">
                        <p className='book-ride-card-heading-2'>To</p>
                        <p>{offerRideTo}</p>
                        <p className='book-ride-card-heading-2'>Price</p>
                        <p>{offerRidePrice}</p>
                    </div>
                </div>
                <button type="submit" className='book-ride-submit-button' onClick={submitBookRide}>Book Ride</button>
            </div>
        </>
    )
}