<script lang="ts" setup>
import BidFees from '../types/bidFees';

interface FeesTableProps
{
    total: number
    fees: BidFees 
}

defineProps<FeesTableProps>();

</script>

<template>
    <table class="min-w-full text-sm text-left border-collapse">
        <thead class="bg-gray-50">
            <tr class="divide-x divide-gray-200">
                <th class="px-4 py-2 font-semibold">Basic</th>
                <th class="px-4 py-2 font-semibold">Special</th>
                <th class="px-4 py-2 font-semibold">Association</th>
                <th class="px-4 py-2 font-semibold">Storage</th>
                <th class="px-4 py-2 font-semibold">Total ($)</th>
            </tr>
        </thead>
        <tbody class="divide-y divide-gray-200">
            <tr class="divide-x divide-gray-200">
                <td class="px-4 py-2">{{ fees.basicBuyerFee }}</td>
                <td class="px-4 py-2">{{ fees.sellerSpecialFee }}</td>
                <td class="px-4 py-2">{{ fees.associationFee }}</td>
                <td class="px-4 py-2">{{ fees.storageFee }}</td>
                <td class="px-4 py-2 font-semibold">{{ total }}</td>
            </tr>
        </tbody>
    </table>
</template>

<style lang="scss" scoped>


</style>