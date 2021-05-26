import { Module } from "vuex";
import { AuthManagementService, OpenAPI } from "@/apiService";
import { parseJwt } from "@/utils";
import { logError } from "@/logger";

interface JWTSchema {
    Id: string,
    sub: string
    email: string
    jti: string
    "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": string
}

export const identity: Module<IdenityState, GlobalState> = {
    mutations: {
        user_logged(state, userInfo: UserInfo) {
            state.userInfo = userInfo
        }
    },
    actions: {
        async login({ commit }, { email, password }) {
            try {
                const result = await AuthManagementService.login({
                    requestBody: {
                        email,
                        password
                    }
                })
                const token = result.token as string
                const parsedToken: JWTSchema = parseJwt(token)
                OpenAPI.TOKEN = token
                const userInfo: UserInfo = {
                    id: parsedToken.Id,
                    email: parsedToken.email,
                    jti: parsedToken.jti,
                    sub: parsedToken.sub
                }
                commit("user_logged", userInfo)
                return { autenticated: true }
            } catch (error) {
                logError(`User auth failed - ${error}`)
                return { autenticated: false }
            }
        }
    }
}