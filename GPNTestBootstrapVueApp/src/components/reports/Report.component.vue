<template>
  <p class="homeText">
    You recive {{report.reportName}}: In {{report.reportQuarter}} quarter department {{report.department}} sales goods on {{report.sales_sum}}$.
  </p>
</template>
<script>
import RepService from '@/api-services/rep.service'

export default {
  name: 'RepPage',
  data () {
    return {
      report: []
    }
  },
  created () {
    RepService.getFinReport().then((response) => {
      this.report = response.data
    })
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
