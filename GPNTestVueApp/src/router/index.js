import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import NotFound from '@/components/error-pages/NotFound'
import ReportList from '@/components/report/ReportList.component'
import SaleList from '@/components/report/SaleList.component'
import SaleCreate from '@/components/report/SaleCreate'

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
      path: '/report/list',
      name: 'ReportList',
      component: ReportList
    },
    {
      path: '/sale/list',
      name: 'SaleList',
      component: SaleList
    },
    {
      path: '/sale/create',
      name: 'SaleCreate',
      component: SaleCreate
    },
    {
      path: '*',
      name: 'NotFound',
      component: NotFound
    }
  ]
})
