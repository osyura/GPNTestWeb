<template>
  <div class="form-wrapper">
    <b-form @submit.prevent="sendRequest">
      <b-form-group :label-cols="2"
                    breakpoint="md"
                    horizontal
                    label="Name of Report:"
                    for="repName">
        <b-col :md="5">
          <b-input id="repName"
                   v-model="formData.reportName"
                   maxlength="100"
                   required />
        </b-col>
      </b-form-group>
      <b-form-group :label-cols="2"
                    breakpoint="md"
                    horizontal
                    label="What quarter:"
                    for="repQuarter">
        <b-col :md="5">
          <select id="repQuarter" v-model="formData.reportQuarter" class="m-md-2" required>
            <option disabled value="">Pick one of</option>
            <option v-for="quarter in quarters" :key="quarter.value" :value="quarter.value">{{quarter.key}}</option>
          </select>
          <span>Picked: {{formData.reportQuarter}}</span>
        </b-col>
      </b-form-group>
      <b-form-group :label-cols="2"
                    breakpoint="md"
                    horizontal
                    label="Department name:"
                    for="repDep">
        <b-col :md="5">
          <b-input id="repDep"
                   v-model="formData.department"
                   maxlength="100"
                   required />
        </b-col>
      </b-form-group>
      <br><br>
      <b-col :md="5"
             offset="4">
        <b-button type="submit"
                  variant="info">Send request</b-button>
      </b-col>
    </b-form>
    <p class="homeText" id="rep_text">
      You recive {{report.reportName}}: In {{report.reportQuarter}} quarter department {{report.department}} sales goods on {{report.sales_sum}}$.
    </p>
  </div>

</template>
<script>
import RepService from '@/api-services/rep.service'
import SalesService from '@/api-services/sales.service'

export default {
  name: 'RepPage',
  data () {
    return {
      formData: {
        reportName: '',
        reportQuarter: '',
        department: ''
      },
      report: [],
      quarters: []
    }
  },
  created () {
    SalesService.getQuarters().then((response) => {
      this.quarters = response.data
    })
  },
  methods: {
    sendRequest () {
      RepService.getFinReport(this.formData.reportName, this.formData.reportQuarter, this.formData.department).then((response) => {
        this.report = response.data
      })
    }
  }
}
</script>
<style scoped>
  .homeText {
    font-size: 35px;
    color: red;
    text-align: center;
    position: relative;
    top: 30px;
    text-shadow: 2px 2px 2px gray;
  }
</style>
