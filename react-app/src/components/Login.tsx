import React from 'react';
import { useMsal } from '@azure/msal-react';
import { loginRequest } from '../config/authConfig';

const Login: React.FC = () => {
  const { instance } = useMsal();

  const handleLogin = (method: string) => {
    if (method === "popup") {
      instance.loginPopup(loginRequest).catch(e => {
        console.error(e);
      });
    } else if (method === "redirect") {
      instance.loginRedirect(loginRequest).catch(e => {
        console.error(e);
      });
    }
  };

  return (
    <button onClick={() => handleLogin("popup")}>Sign in using Popup</button>
  );
};

export default Login;
