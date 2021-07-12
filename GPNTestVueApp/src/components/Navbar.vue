<template>
  <a-menu v-model="current" mode="horizontal">
    <a-menu-item key="home"> <a-icon type="home" /><router-link :to="{ name: 'Home' }">Home</router-link></a-menu-item>
    <a-menu-item key="salelist"> <a-icon type="appstore" /><router-link :to="{ name: 'SaleList' }">Sale Actions</router-link></a-menu-item>
    <a-menu-item key="reportlist"> <a-icon type="appstore" /><router-link :to="{ name: 'ReportList' }">Sale Reports</router-link></a-menu-item>
  </a-menu>
</template>
<script>
export default {
  name: 'Navbar'
}
</script>
