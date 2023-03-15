import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import '../src/CSS/SignUp.css';
import '../src/CSS/LogIn.css'
import '../src/CSS/Options.css'
import '../src/CSS/Rides.css'
import { BrowserRouter, Routes } from 'react-router-dom';
import { Provider } from 'react-redux';
import { reducers } from "./state/Reducers/CombineReducers"
import { applyMiddleware, legacy_createStore as createStore } from 'redux'
import thunk from "redux-thunk"
const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
const store = createStore(reducers,
  applyMiddleware(thunk))
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Provider store={store}>
        <App />
      </Provider>
    </BrowserRouter>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
