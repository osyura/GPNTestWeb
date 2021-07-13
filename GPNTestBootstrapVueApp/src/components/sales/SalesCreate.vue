<template>
  <b-container fluid>
    <div class="form-wrapper">
      <b-form @submit.prevent="createSale">
        <b-form-group :label-cols="2"
                      breakpoint="md"
                      horizontal
                      label="Name of the Department:"
                      for="department">
          <b-col :md="5">
            <b-input id="department"
                     v-model="formData.department"
                     maxlength="60"
                     required />
          </b-col>
        </b-form-group>
        <b-form-group :label-cols="2"
                      breakpoint="md"
                      horizontal
                      label="Sale prise:"
                      for="price">
          <b-col :md="5">
            <b-input id="price"
                     v-model="formData.price"
                     maxlength="100"
                     required />
          </b-col>
        </b-form-group>
        <b-form-group :label-cols="2"
                      breakpoint="md"
                      horizontal
                      label="Sale quarter:"
                      for="quarter">
          <b-col :md="5">
            <select id="quarter" v-model="formData.quarter" class="m-md-2" required>
              <option disabled value="">Pick one of</option>
              <option v-for="quarter in quarters" :key="quarter.value" :value="quarter.value">{{quarter.key}}</option>
            </select>
            <span>Picked: {{formData.quarter}}</span>
          </b-col>
        </b-form-group>

        <br><br>
        <b-col :md="5"
               offset="4">
          <b-button type="submit"
                    variant="info">Save</b-button>
          <b-button :to="{ name: 'SalesList' }"
                    variant="danger">Cancel</b-button>
        </b-col>
      </b-form>
    </div>
    <b-modal
      ref="alertModal"
      :title="alertModalTitle"
      :ok-only="true"
      @ok="onAlertModalOkClick">
      <p class="my-4">{{ alertModalContent }}</p>
    </b-modal>
  </b-container>
</template>

<script>
import SalesService from '@/api-services/sales.service'

export default {
  name: 'SalesCreate',
  data () {
    return {
      formData: {
        department: '',
        price: '',
        quarter: ''
      },
      alertModalTitle: '',
      alertModalContent: '',
      isSuccessfully: false,
      quarters: []
    }
  },
  created () {
    SalesService.getQuarters().then((response) => {
      this.quarters = response.data
    })
  },
  methods: {
    createSale () {
      SalesService.create(this.formData).then(() => {
        this.isSuccessfully = true
        this.alertModalTitle = 'Successfully'
        this.alertModalContent = 'Successfully created Sale'
        this.$refs.alertModal.show()
        this.formData = {
          department: '',
          price: '',
          quarter: ''
        }
      }).catch((error) => {
        this.isSuccessfully = false
        this.alertModalTitle = 'Error'
        this.alertModalContent = error.response.data
        this.$refs.alertModal.show()
      })
    },
    onAlertModalOkClick () {
      if (this.isSuccessfully) {
        this.$router.push({ name: 'SalesList' })
      }
    }
  }
}
</script>

<style>
.form-wrapper {
  margin-top: 20px;
  min-height: 20px;
  padding: 19px;
  margin-bottom: 20px;
  background-color: #f5f5f5;
  border: 1px solid #e3e3e3;
  border-radius: 4px;
  box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
}
</style>
