import Vue from 'vue'
import VueRouter from 'vue-router'
import { Home, About, Login } from '@/views'

const Autenticated = "Autenticated"
const NotAutenticated = "NotAutenticated"

Vue.use(VueRouter)

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
        meta: {
            layout: Autenticated
        }
    },
    {
        path: '/about',
        name: 'About',
        component: About,
        meta: {
            layout: Autenticated
        }
    },
    {
        path: '/login', 
        name: 'Login',
        component: Login,
        meta: {
            layout: NotAutenticated
        }
    }
]

const router = new VueRouter({
    routes
})

export default router
