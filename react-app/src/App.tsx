import * as React from 'react';
import './App.css';
import { Dialog, PrimaryButton, Stack, Text, TextField } from '@fluentui/react';

function App() {
  // eslint-disable-next-line
  const [loginDialogOpen, setLoginDialogOpen] = React.useState(false);
  const [username, setUsername] = React.useState("");
  const [password, setPassword] = React.useState("");

  const handleLogin = () => {
    // TODO: Login
  };

  return (
    <>
      <Stack>
        <Text>Please login to access</Text>
        <PrimaryButton onClick={() => setLoginDialogOpen((previous) => !previous)}>Login</PrimaryButton>
      </Stack>
      <Dialog hidden={!loginDialogOpen} onDismiss={() => setLoginDialogOpen((previous) => !previous)}>
        <TextField label='Username' onChange={(_, newValue) => setUsername(() => newValue ?? "")}></TextField>
        <TextField label='Password' onChange={(_, newValue) => setPassword(() => newValue ?? "")}></TextField>
        <PrimaryButton disabled={username === "" || password === ""} onClick={(_) => handleLogin()}>Login</PrimaryButton>
      </Dialog>
    </>
  );
}

export default App;
