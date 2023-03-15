import Logo from '../Images/logo.png';
import NeedARide from '../Images/needaride1.png'
import JohnCena from '../Images/JohnCena.jpeg'
import {Link,useNavigate} from 'react-router-dom'
export default function Options(){
    let user = JSON.parse(localStorage.getItem("userDetails")||'{}')
    return(
        <>
            <div className='carpool-options'>
                <div className="option-navbar">
                    <img src={Logo} alt="" id='option-ya-logo'/>
                    <div className="display-name-and-photo">
                        <h3>{user.UserName}</h3>
                        <img src={JohnCena} alt="" />
                    </div>
                </div>
                <h2 className='hey-name-display-text'>Hey {user.UserName}!</h2>
                <div className="options-container">
                    <Link to={'/bookaride'} className="book-a-ride"><div><h3>Book a ride</h3></div></Link>
                    <Link to={'/offeraride'} className="offer-a-ride"><div><h3>Offer a ride</h3></div></Link>
                </div>
                <img src={NeedARide} alt="" id='options-need-a-ride'/>
            </div>
        </>
    )
}