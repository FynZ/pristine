<template>
    <div class="card flex justify-center">
        <PanelMenu :model="items" multiple class="w-full md:w-80">
            <template #item="{ item }">
                <router-link v-if="item.route" v-slot="{ href, navigate }" :to="item.route" custom>
                    <a v-ripple class="flex items-center cursor-pointer text-surface-700 dark:text-surface-0 px-4 py-2" :href="href" @click="navigate">
                        <span :class="item.icon" />
                        <span class="ml-2">{{ item.label }}</span>
                    </a>
                </router-link>
                <a v-else v-ripple class="flex items-center cursor-pointer text-surface-700 dark:text-surface-0 px-4 py-2" :href="item.url" :target="item.target">
                    <span :class="item.icon" />
                    <span class="ml-2">{{ item.label }}</span>
                    <span v-if="item.items" class="pi pi-angle-down text-primary ml-auto" />
                </a>
            </template>
        </PanelMenu>
    </div>
</template>

<script setup lang="ts">
import PanelMenu from 'primevue/panelmenu';
import { ref } from "vue";

const items = ref([
{
    label: 'Files',
    icon: 'pi pi-file',
    items: [
    {
        label: 'Documents',
        icon: 'pi pi-file',
        route: '/files/documents'
    },
    {
        label: 'Images',
        icon: 'pi pi-image',
        route: '/files/images'
    }
    ]
},
{
    label: 'Cloud',
    icon: 'pi pi-cloud',
    items: [
    {
        label: 'Upload',
        icon: 'pi pi-cloud-upload',
        route: '/cloud/upload'
    },
    {
        label: 'Download',
        icon: 'pi pi-cloud-download',
        route: '/cloud/download'
    },
    {
        label: 'Sync',
        icon: 'pi pi-refresh',
        route: '/cloud/sync'
    }
    ]
},
{
    label: 'Devices',
    icon: 'pi pi-desktop',
    items: [
    {
        label: 'Mobile',
        icon: 'pi pi-mobile',
        route: '/devices/mobile'
    },
    {
        label: 'Desktop',
        icon: 'pi pi-desktop',
        route: '/devices/desktop'
    },
    {
        label: 'Tablet',
        icon: 'pi pi-tablet',
        route: '/devices/tablet'
    }
    ]
}
]);
</script>
