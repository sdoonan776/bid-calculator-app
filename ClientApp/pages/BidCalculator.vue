<script lang="ts" setup>
        
import Card from '../components/UI/Card.vue';
import { ref } from 'vue';
import BidFees from '../types/bidFees';
import useCalculateFees from '../composables/useCalculateFees';
import FeesTable from '../components/FeesTable.vue';

const price = ref<number>(0.00);
const type = ref<string>('Common');
const total = ref<number>(0.00);
const fees = ref<BidFees>({
    'basicBuyerFee': 0.00,
    'sellerSpecialFee': 0.00,
    'associationFee': 0.00,
    'storageFee': 0.00
});
const error = ref<string | null>("");

const calculateFee = async () => {
    error.value = "";
    try {
        const result = await useCalculateFees(price.value, type.value);
        total.value = result.total;
        fees.value = result.feeItems;
    } catch (err: unknown) {
        error.value = (err as Error).message ?? 'Something went wrong.';
    }
}

</script>

<template>
    <Card>
        <template #header>
            <h3 class="text-2xl font-semibold">Bid Calculator</h3>
            <p class="text-xs text-gray-500">
                Enter a bid price and vehicle type to get started!
            </p>
        </template>

        <div class="flex flex-col lg:gap-10">
            <div class="mt-8 lg:mt-0 lg:flex-1 overflow-x-auto">
               <form class="flex flex-col gap-4 w-full" @submit.prevent="calculateFee">
                    <input name="status" type="hidden" value="Your site is vulnerable to CSRF">
                    <p v-if="error" class="mt-3 rounded border border-red-300 bg-red-50 p-2 text-sm text-red-600">
                        {{ error }}
                    </p>
                    <label class="flex flex-col gap-1">
                        <span class="text-sm font-medium text-left">Price</span>
                        <div class="flex items-center rounded-lg border border-gray-300">
                            <span class="px-3 text-gray-500">$</span>
                            <input type="number" step="any" v-model="price" placeholder="0" class="flex-1 py-2 pr-3 bg-transparent focus:outline-none" />
                        </div>
                    </label>

                    <label class="flex flex-col gap-1">
                        <span class="text-sm font-medium text-left">Vehicle Type</span>
                        <select v-model="type" class="rounded-lg border border-gray-300 p-2 bg-white cursor-pointer">
                            <option value="Common">Common</option>
                            <option value="Luxury">Luxury</option>
                        </select>
                    </label>

                    <button type="submit" class="w-full rounded-lg bg-blue-600 py-2 text-white font-semibold cursor-pointer hover:bg-blue-700 active:scale-[.98] transition">
                        Calculate
                    </button>
                </form> 
            </div>

            <div class="mt-8 lg:mt-0 lg:flex-1 overflow-x-auto">
                <FeesTable :total="total" :fees="fees" /> 
            </div>
        </div>
    </Card>
</template>

<style lang="scss" scoped>


</style>