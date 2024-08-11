<template>
    <Button label="Login" severity="success" @click="handleLogin"/>
</template>

<script setup lang="ts">
import Button from 'primevue/button';
import { useAuth0 } from '@auth0/auth0-vue';
const { loginWithRedirect } = useAuth0();

const handleLogin = () => {
    loginWithRedirect({
        appState: {
            target: '/'
        }
    });
}
</script>