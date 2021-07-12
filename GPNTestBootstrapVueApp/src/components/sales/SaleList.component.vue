<template>
  <div>
    <b-row>
      <b-col md="2"
             offset-md="10">
        <router-link :to="{ name: 'SalesCreate' }">Create sale</router-link>
      </b-col>
    </b-row>
    <br>
    <b-row>
      <b-col md="12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <td>Department</td>
                <td>Price</td>
                <td>Quarter</td>
                <td>Delete</td>
              </tr>
            </thead>
            <tbody>
              <tr>
                <sale-list-row v-for="sale in sales"
                               :key="sale.id"
                               :sale="sale"
                               @delete="deleteSale"/>
              </tr>
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>
    <b-modal ref="deleteConfirmModal"
             title="Confirm your action"
             @ok="onDeleteConfirm"
             @hide="onDeleteModalHide">
      <p class="my-4">Are you sure you want to delete this sale?</p>
    </b-modal>
    <b-modal ref="alertModal"
             :title="alertModalTitle"
             :ok-only="true">
      <p class="my-4">{{ alertModalContent }}</p>
    </b-modal>
  </div>
</template>
<script>
import SalesService from '@/api-services/sales.service'
import SaleListRow from '@/components/sales/SalesListRow'

export default {
  name: 'SalesList',
  components: {
    SaleListRow
  },
  data () {
    return {
      sales: [],
      selectedSaleId: null,
      alertModalTitle: '',
      alertModalContent: ''
    }
  },
  created () {
    this.fetchSales()
  },
  methods: {
    deleteSale (saleId) {
      this.selectedSaleId = saleId
      this.$refs.deleteConfirmModal.show()
    },
    fetchSales () {
      SalesService.getAll().then((response) => {
        this.sales = response.data
      })
    },
    onDeleteConfirm () {
      SalesService.delete(this.selectedSaleId).then(() => {
        this.alertModalTitle = 'Successfully'
        this.alertModalContent = 'Successfully deleted Sale'
        this.$refs.alertModal.show()
        this.fetchSales()
      }).catch((error) => {
        this.alertModalTitle = 'Error'
        this.alertModalContent = error.response.data
        this.$refs.alertModal.show()
      })
    },
    onDeleteModalHide () {
      this.selectedSaleId = null
    }
  }
}
</script>
