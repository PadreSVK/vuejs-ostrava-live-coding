import { NavigationGuard } from "vue-router";
import store from "@/store";
import { isDevelopment, configuration } from "@/configuration";

const authenticationGuard: NavigationGuard = async function (to, from, next) {
    const requireAutentication = to.meta.layout == "Autenticated"
    const userInfo = (store.state as any).identity.userInfo
    if (userInfo || !requireAutentication) {
        next()
    }
    else {
        if (isDevelopment()) {
            const { autenticated } = await store.dispatch("login", {
                email: configuration.develop?.credentials.email,
                password: configuration.develop?.credentials.password,
            });
            if (autenticated) {
                next()
                return;
            }
        }

        next({ name: "Login", query: { redirect: to.path } })
    }
}

export { authenticationGuard }