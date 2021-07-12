<template>
  <div>
    <router-link :to="{ name: 'SaleCreate' }">Create report</router-link>
    <a-table :columns="columns" :data-source="sales">
      <a slot="name" slot-scope="text">{{ text }}</a>
    </a-table>
  </div>
</template>
<script>
import RepService from '@/api-services/rep.service'

const columns = [
  {
    title: 'Department Name',
    dataIndex: 'name',
    key: 'name',
    scopedSlots: { customRender: 'name' }
  },
  {
    title: 'Age',
    dataIndex: 'age',
    key: 'age',
    width: 80
  }
]

export default {
  name: 'SaleList',
  data () {
    return {
      sales: [],
      columns
    }
  },
  created () {
    RepService.getAll().then((response) => {
      this.sales = response.data
    })
  }
}
</script>
