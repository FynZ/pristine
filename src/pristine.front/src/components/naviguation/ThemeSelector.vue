<template>
    <template v-if="icon == 'pi-moon'">
        <Button icon="pi pi-moon" aria-label="Toggle Color Scheme" @click="toggleColorScheme()"/>
    </template>
    <template v-else>
        <Button icon="pi pi-sun" aria-label="Toggle Color Scheme" @click="toggleColorScheme()"/>
    </template>
</template>

<script setup lang="ts">
import Button from 'primevue/button';
import { ref } from 'vue';

const dark = "dark";
const light = "light";

const defaultTheme = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)') ? dark : light;
const icon = ref<string>(defaultTheme);

const toggleColorScheme = () => {
    const element = document.querySelector('html');
    element?.classList.toggle('my-app-dark');

    icon.value = icon.value === dark ? "pi-sun" : "pi-moon";
}
</script>