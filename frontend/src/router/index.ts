import Vue from 'vue'
import VueRouter from 'vue-router'
import { Home, About, Login, Register, Administration } from '@/views'
import { authenticationGuard } from './guards'

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
    },
    {
        path: '/register',
        name: 'Register',
        component: Register,
        meta: {
            layout: NotAutenticated
        }
    },
    {
        path: '/administration',
        name: 'Administration',
        component: Administration,
        meta: {
            layout: Autenticated
        }
    }
]

const router = new VueRouter({
    routes
})
router.beforeEach(authenticationGuard)
export default router
