import Logo from '../Images/logo.png';
import signup from '../Images/signup.png'
import needaride from '../Images/needaride.png'
import { Link, useNavigate } from 'react-router-dom';
import { RootState } from '../state/Reducers/CombineReducers';
import { bindActionCreators } from "redux";
import { useDispatch, useSelector } from 'react-redux';
import { signupActionCreator } from '../state/action-creator/actionCreator';
export default function SignUp() {
    const stateVariable = useSelector((state: RootState) => state.SignUp)
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const { signUpName, signUpPassword, signUpConfirmPassword } = bindActionCreators(signupActionCreator, dispatch)
    const submitSignup = async () => {
        if (stateVariable.password != stateVariable.confirmPassword) {
            alert('Please Enter Same Password');
        }
        else {
            const account = {
                userName: stateVariable.name,
                password: stateVariable.password
            }
            await fetch('https://localhost:7093/api/accounts', {
                method: 'POST',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify(account)
            }).then(r => r.json()).then(res => { });
            navigate('/login')
        }
    }
    return (
        <>
            <div className="sign-up-page" >
                <div className='sign-up-part-1'>
                    <img src={Logo} alt="" id="ya-logo" />
                    <div className="sign-up-part-1-text">
                        <h1>TURN <span className='miles-text'>MILES</span></h1>
                        <h1>INTO <span className='money-text'>MONEY</span></h1>
                        <h3>RIDES ON TAP</h3>
                    </div>
                    <img src={needaride} alt="" id='sign-up-need-a-ride' />
                </div>
                <div className='sign-up-part-2'>
                    <div className="sign-up-form" >
                        <h2 className='sign-up-heading'>Sign Up</h2>
                        <input type="text" placeholder="User Name" onChange={(e) => signUpName(e.target.value)}></input>
                        <input type="password" placeholder="Password" onChange={(e) => signUpPassword(e.target.value)}></input>
                        <input type="password" placeholder="Confirm Password" onChange={(e) => signUpConfirmPassword(e.target.value)}></input>
                        <button type="submit" className='sign-up-submit-button' onClick={submitSignup}>Submit</button>
                        <p className='already-a-member-text'>Already a member?<Link className='log-in-link-text' to={'/login'} > LOG IN</Link></p>
                    </div>
                    <img src={signup} alt="" id="sign-up-img" />
                </div>
            </div>
        </>
    )
}