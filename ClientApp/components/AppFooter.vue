<script lang="ts" setup>
import { ref } from 'vue';
const date = ref<Date>(new Date);        
</script>

<template>
    <footer class="bg-white py-10 w-full text-center fixed bottom-0">
        <p>Progi | All Rights Reserved &copy {{ date.getFullYear() }} </p> 
    </footer>
</template>

<style lang="scss" scoped>


</style>