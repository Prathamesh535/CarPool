import Logo from '../Images/logo.png';
import JohnCena from '../Images/JohnCena.jpeg'
import Rides from '../Images/rides.png'
import { useState } from 'react';
import { offerRideActionCreator } from '../state/action-creator/actionCreator';
import { useDispatch, useSelector } from 'react-redux';
import { bindActionCreators } from 'redux';
import { RootState } from '../state/Reducers/CombineReducers';
export default function OfferARide() {
    let user = JSON.parse(localStorage.getItem("userDetails") || '{}')
    let token = localStorage.getItem("user")
    const dispatch = useDispatch()
    const {offerARideFrom,offerARideTo,offerARideDate} = bindActionCreators(offerRideActionCreator,dispatch)
    const offerRideVariable = useSelector((state:RootState)=>state.OfferRide)
    const [offerCard2, myOfferCard2] = useState({ display: 'block' })
    const displayOfferCard = () => {
        myOfferCard2({ display: 'block' })
    }
    const [addListInput, myAddListInput] = useState<{ value: string, plusButton: boolean }[]>([{ value: "", plusButton: true }])
    const [stopListObject, setStopListObject] = useState([{}])
    function handleOnChange(e: React.ChangeEvent<HTMLInputElement>, index: number) {
        const list: { value: string, plusButton: boolean }[] = addListInput;
        list[index].value = e.target.value;
        myAddListInput((x) => [...list])
        const value = stopList
        value[index] = e.target.value
        setStopList(value)
        let stopListObject = [{}];
        stopList.forEach(element => {
            stopListObject.push({ stopName: element })
        });
        stopListObject = stopListObject.splice(1, stopListObject.length);
        setStopListObject(stopListObject)
    }
    function handlePlus(index: number) {
        const list: { value: string, plusButton: boolean }[] = addListInput;
        list[index].plusButton = false;
        list.push({ value: "", plusButton: true })
        myAddListInput([...list]);
    }
    const [stopList, setStopList] = useState<Array<string>>([])
    const [offerTiming, setOfferTiming] = useState('')
    const [offerSeats, setOfferSeats] = useState<Number>()
    const [seatNumber1, setSeatNumber1] = useState({})
    const [seatNumber2, setSeatNumber2] = useState({})
    const [seatNumber3, setSeatNumber3] = useState({})
    const [purpleBackground1, setPurpleBackground1] = useState({})
    const [purpleBackground2, setPurpleBackground2] = useState({})
    const [purpleBackground3, setPurpleBackground3] = useState({})
    const [purpleBackground4, setPurpleBackground4] = useState({})
    const [purpleBackground5, setPurpleBackground5] = useState({})
    const seatNumber = (seat: number) => {
        setOfferSeats(seat)
        switch (seat) {
            case 1:
                setSeatNumber1({ backgroundColor: "#9319ff", color: "white", border: '1px solid #9319ff' })
                setSeatNumber2({ backgroundColor: "white", color: "black" })
                setSeatNumber3({ backgroundColor: "white", color: "black" })
                break;
            case 2:
                setSeatNumber2({ backgroundColor: "#9319ff", color: "white", border: '1px solid #9319ff' })
                setSeatNumber1({ backgroundColor: "white", color: "black" })
                setSeatNumber3({ backgroundColor: "white", color: "black" })
                break;
            case 3:
                setSeatNumber3({ backgroundColor: "#9319ff", color: "white", border: '1px solid #9319ff' })
                setSeatNumber2({ backgroundColor: "white", color: "black" })
                setSeatNumber1({ backgroundColor: "white", color: "black" })
                break;
        }
    }
    const timing = (time: string) => {
        setOfferTiming(time)
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
    const offerRideSubmit = () => {
        const offerRide = {
            From: offerRideVariable.offerRideFrom,
            To: offerRideVariable.offerRideTo,
            TotalSeats: offerSeats,
            AvailableSeats: offerSeats,
            OfferTiming: offerTiming,
            OfferDate: offerRideVariable.offerRideDate,
            AccountId: user.AccountId,
            Price: 50,
            Destinations: stopListObject
        }
        fetch('https://localhost:7093/api/offerrides', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(offerRide)
        }).then(r => r.json())
            .then(response => {
                if (response.status == 400) {
                    console.log("Wrong")
                }
            });
        window.location.reload();
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
                        <h2>Offer a Ride</h2>
                        <p className='book-ride-card-heading-2'>We get you the matches asap!</p>
                        <div className='book-ride-form'>
                            <label htmlFor="">From</label>
                            <input type="text" onChange={(e)=>offerARideFrom(e.target.value)} />
                            <label htmlFor="">To</label>
                            <input type="text" onChange={(e)=>offerARideTo(e.target.value)} />
                            <label htmlFor="">Date</label>
                            <input type="date" onChange={(e)=>offerARideDate(e.target.value)} />
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
                            <a className='next-form' onClick={displayOfferCard}>Next{'>>'}</a>
                        </div>
                    </div>
                    <div className="book-ride-card" style={offerCard2}>
                        <h2>Offer a Ride</h2>
                        <p className='book-ride-card-heading-2'>We get you the matches asap!</p>
                        <div className='book-ride-form'>
                            <div className="stops-vertical-scroll-bar">
                                {addListInput.map((x, index) => {
                                    return (
                                        <div key={index}>
                                            <label>Stop {index + 1}</label>
                                            <div>
                                                <input required key={index} type='input' value={addListInput[index].value} onChange={(e) => { handleOnChange(e, index) }} />
                                                {x.plusButton && <span className='add-input-text' onClick={() => { handlePlus(index) }}>+</span>}
                                            </div>
                                        </div>)
                                })}
                                <div className='available-seats-and-price'>
                                    <div className="available-seats">
                                        <p className='available-seats-and-price-text'>Available Seats</p>
                                        <div className="seats-available">
                                            <div className='seats-numbers' style={seatNumber1} onClick={() => seatNumber(1)}>1</div>
                                            <div className='seats-numbers' style={seatNumber2} onClick={() => seatNumber(2)}>2</div>
                                            <div className='seats-numbers' style={seatNumber3} onClick={() => seatNumber(3)}>3</div>
                                        </div>
                                    </div>
                                    <div className="price">
                                        <p className='available-seats-and-price-text'>Price</p>
                                        <p>100$</p>
                                    </div>
                                </div>
                                <button type="submit" className='book-ride-submit-button' onClick={offerRideSubmit}>Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
                <img src={Rides} alt="" className='rides-background-image' />
            </div>
        </>
    )
}
