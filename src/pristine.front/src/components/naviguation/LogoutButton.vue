<template>
    <Button label="Logout" severity="danger" @click="handleLogout"/>
</template>

<script setup lang="ts">
import Button from 'primevue/button';
import { useAuth0 } from '@auth0/auth0-vue';

const { logout } = useAuth0();

const handleLogout = () => {
    logout({
        logoutParams: {
            returnTo: window.location.origin
        }
    });
}
</script>