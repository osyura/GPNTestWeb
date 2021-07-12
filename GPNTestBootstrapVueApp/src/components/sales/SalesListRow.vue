<template>
  <tr>
    <td>{{ sale.department }}</td>
    <td>{{ sale.price }}</td>
    <td>{{ sale.quarter }}</td>
    <td>
      <b-button variant="danger" @click="onDeleteClick">Delete</b-button>
    </td>
  </tr>
</template>
<script>
export default {
  name: 'SaleListRow',
  props: ['sale'],
  methods: {
    onDeleteClick () {
      this.$emit('delete', this.sale.id)
    }
  }
}
</script>
