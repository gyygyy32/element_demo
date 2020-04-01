import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'

Vue.use(Router)

export default new Router({
  mode: "history",
  routes: [
    {
      path: '/',
      name: 'Query',
      component:()=> import('../Views/Crud.vue')
    },
    {
      path:'/Add',
      name:'Add',
      component:()=>import('@/Views/Add.vue')//Add
    },
    {
      path:'/Edit',
      name:'Edit',
      component:()=>import('@/Views/Edit')
    }
  ]
})
