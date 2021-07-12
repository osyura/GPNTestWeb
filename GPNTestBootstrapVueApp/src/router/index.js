import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import NotFound from '@/components/error-pages/NotFound'
import SalesList from '@/components/sales/SaleList.component'
import SalesCreate from '@/components/sales/SalesCreate'
import RepPage from '@/components/reports/Report.component'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/sales/list',
      name: 'SalesList',
      component: SalesList
    },
    {
      path: '/sales/create',
      name: 'SalesCreate',
      component: SalesCreate
    },
    {
      path: '/report',
      name: 'ReportPage',
      component: RepPage
    },
    {
      path: '*',
      name: 'NotFound',
      component: NotFound
    }
  ]
})
