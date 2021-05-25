import { NavigationGuard } from "vue-router";
import store from "@/store";

const authenticationGuard: NavigationGuard = async function (to, from, next) {
    const requireAutentication = to.meta.layout == "Autenticated"
    const userInfo = (store.state as any).identity.userInfo
    if (userInfo || !requireAutentication) {
        next()
    }
    else {
        next({ name: "Login", query: { redirect: to.path } })
    }
}

export { authenticationGuard }