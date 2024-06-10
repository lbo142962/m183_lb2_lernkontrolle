import { Configuration, PopupRequest } from '@azure/msal-browser';

const msalConfig: Configuration = {
  auth: {
    clientId: '492e5d8e-90c6-4a70-8ced-8ebbd892859f',
    authority: 'https://login.microsoftonline.com/38a3f06c-4837-4dba-abb4-7a03b39bbf5f',
    redirectUri: 'http://localhost:3000'
  },
  cache: {
    cacheLocation: "localStorage",
    storeAuthStateInCookie: true,
  }
};

const loginRequest: PopupRequest = {
  scopes: ['User.Read']
};

export { msalConfig, loginRequest };
