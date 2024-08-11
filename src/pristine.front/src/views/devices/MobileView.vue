<script setup lang="ts">
import { ref } from 'vue'
</script>

<template>
    <div class="post">
        <div v-if="loading" class="loading">Loading...</div>
        <div v-else class="content">{{ data }}</div>
    </div>
</template>

<script lang="ts">
const loading = ref<bool>(true);
const data = ref<string>(null);

let response = await fetch('/api/pokemons').then(data => data);

console.log(response);

data.value = response;
loading.value = false;

</script>