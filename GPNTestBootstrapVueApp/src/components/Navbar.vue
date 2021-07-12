<template>
  <b-navbar toggleable="md"
            type="dark"
            variant="info">
    <b-navbar-brand :to="{ name: 'Home' }">Home</b-navbar-brand>
    <b-navbar-nav>
      <b-nav-item :to="{ name: 'SalesList' }">Sales Actions</b-nav-item>
      <b-nav-item :to="{ name: 'ReportPage' }">Report Actions</b-nav-item>
    </b-navbar-nav>
  </b-navbar>
</template>
<script>
export default {
  name: 'Navbar'
}
</script>
