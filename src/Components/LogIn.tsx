import Logo from '../Images/logo.png';
import needaride from '../Images/needaride.png'
import signup from '../Images/signup.png'
import { useEffect, useState } from 'react';
import { Link, Routes, Route, BrowserRouter, Navigate, useNavigate } from 'react-router-dom';
import { loginActionCreator } from '../state/action-creator/actionCreator';
import { json } from 'stream/consumers';
import { bindActionCreators } from 'redux';
import { useDispatch } from 'react-redux';
import { useSelector } from 'react-redux';
import { RootState } from '../state/Reducers/CombineReducers';
interface Details {
    accountId: number,
    userName: string,
    password: string
}
export default function LogIn() {
    const [userDetails, setUserDetails] = useState<Array<Details>>([])
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const {loginName,loginPassword} = bindActionCreators(loginActionCreator,dispatch);
    const loginVariable = useSelector((state:RootState)=>state.Login)
    const submitLogin = async () => {
        let user = {
            UserName: loginVariable.loginName,
            Password: loginVariable.loginPassword
        }
        await fetch('https://localhost:7093/api/accounts', {
        }).then(r => r.json()).then(res => {
            setUserDetails(res)
        });
        fetch('https://localhost:7093/api/login', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(user)
        }).then(res => {
            if (res.status == 401) {
                navigate('/login')
                alert('Wrong Credentials')
                window.location.reload()
            }
            else if (res.status == 200) {
                navigate('/options')
            }
            return res.text();
        })
            .then((response) => {
                localStorage.setItem("user", response)
            })
            .catch(error => { console.log(error) });
        for (let i = 0; i < userDetails.length; i++) {
            if (userDetails[i].userName == user.UserName && userDetails[i].password == user.Password) {
                let Details = {
                    AccountId: userDetails[i].accountId,
                    UserName: loginVariable.loginName
                }
                localStorage.setItem("userDetails", JSON.stringify(Details))
                break;
            }
        }
    }
    return (
        <div>
            <div className="log-in-page">
                <div className="log-in-page-part-1">
                    <img src={Logo} alt="" id="ya-logo" />
                    <div className="sign-up-part-1-text">
                        <h1>TURN <span className='miles-text'>MILES</span></h1>
                        <h1>INTO <span className='money-text'>MONEY</span></h1>
                        <h3>RIDES ON TAP</h3>
                    </div>
                    <img src={needaride} alt="" id='log-in-need-a-ride' />
                </div>
                <div className="log-in-page-part-2">
                    <div className="log-in-form"  >
                        <h2 className='log-in-heading'>Log In</h2>
                        <input type="text" placeholder="User Name" onChange={(e)=>loginName(e.target.value)}></input>
                        <input type="password" placeholder="Password" onChange={(e)=>loginPassword(e.target.value)}></input>
                        <button type="submit" className='log-in-submit-button' onClick={submitLogin}>Submit</button>
                        <p className='not-a-member-yet-text'>Not a member yet? <Link className='sign-up-link-text' to={'/'}>SIGN UP</Link></p>
                    </div>
                    <img src={signup} alt="" id="log-in-img" />
                </div>
            </div>
        </div>

    )
}