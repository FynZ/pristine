<template>
    <Avatar :image="image" shape="circle" />
</template>

<script setup lang="ts">
import Avatar from 'primevue/avatar';
import { useAuth0 } from '@auth0/auth0-vue';
import { ref } from 'vue';

const { user } = useAuth0();

const image = ref("https://www.pokepedia.fr/images/thumb/e/ef/Bulbizarre-RFVF.png/250px-Bulbizarre-RFVF.png");

if (user.value && user.value.picture)
{
    image.value = user.value.picture;
}

console.log(image.value);
</script>