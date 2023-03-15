import SignUp from './Components/SignUp';
import LogIn from './Components/LogIn';
import Options from './Components/Options'
import BookARide from './Components/BookARide';
import OfferARide from './Components/OfferARide';
import { Link, Routes, Route, BrowserRouter, useNavigate, Navigate } from 'react-router-dom';
import './App.css';
import { useState } from 'react';

function App() {
  const [authLogin] = useState(true)
  const nav = useNavigate();
  return (
    <div>
      <Routes>
        <Route path='/' element={<SignUp />}></Route>
        <Route path='/login' element={<LogIn />}></Route>
        {authLogin ? (
          <>
            <Route path='/options' element={<Options />}></Route>
            <Route path='/bookaride' element={<BookARide />}></Route>
            <Route path='/offeraride' element={<OfferARide />}></Route>
          </>
        ) : (<>
          <Route path='/login' element={<LogIn/> }></Route>
        </>)
        }
        <Route />
      </Routes>
    </div>
  );
}

export default App;
