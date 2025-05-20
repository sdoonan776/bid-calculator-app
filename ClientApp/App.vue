<script lang="ts" setup>
import AppFooter from './components/AppFooter.vue';
import BidCalculator from './pages/BidCalculator.vue';
</script>

<template>
   <div class="min-h-screen flex flex-col bg-[#FDFDFC] text-[#1b1b18]">
        <main class="flex-1 flex items-center justify-center px-4">
            <BidCalculator />
        </main>
        <AppFooter />
    </div>
</template>