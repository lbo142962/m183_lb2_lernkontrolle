import { Configuration, PopupRequest } from '@azure/msal-browser';

const msalConfig: Configuration = {
  auth: {
    clientId: '1ea00890-3bbe-4073-946a-6cb731680f37',
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
