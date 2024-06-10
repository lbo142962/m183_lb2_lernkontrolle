import React from 'react';
import { useIsAuthenticated } from '@azure/msal-react';
import Login from './components/Login';
import { Header } from './components/Header';
import { NotenList } from './components/NotenList';

const App: React.FC = () => {
  const isAuthenticated = useIsAuthenticated();

  return (
    <div>
      {isAuthenticated ? (
        <>
          <Header />
          <NotenList />
        </>
      ) : (
        <Login />
      )}
    </div>
  );
};

export default App;
