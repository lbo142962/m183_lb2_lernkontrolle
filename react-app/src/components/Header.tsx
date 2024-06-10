import { useMsal } from '@azure/msal-react';
import { PrimaryButton } from '@fluentui/react';

export const Header = () => {
    const { accounts, instance } = useMsal();

    const handleLogout = () => {
        instance.logoutRedirect({ postLogoutRedirectUri: '/' });
    };

    return (
        <header style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', padding: '1rem' }}>
            <h2>Welcome, {accounts[0] ? accounts[0].username : 'User'}</h2>
            <PrimaryButton onClick={handleLogout} text="Logout" />
        </header>
    );
};
