import { Module } from "vuex";
import { AuthManagementService, OpenAPI } from "@/apiService";
import { GlobalState } from "@/store/interfaces";
import { parseJwt } from "@/utils";

export interface UserInfo {
    id: string
    sub: string
    email: string
    jti: string
}

interface JWTSchema {
    Id: string,
    sub: string
    email: string
    jti: string
    "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": string
}

export interface IdenityState {
    userInfo: UserInfo
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
                const result = await AuthManagementService.postAuthManagementService1({
                    requestBody: {
                        email,
                        password
                    }
                })

                const parsedToken: JWTSchema = parseJwt(result.token)
                OpenAPI.TOKEN = result.token
                const userInfo: UserInfo = {
                    id: parsedToken.Id,
                    email: parsedToken.email,
                    jti: parsedToken.jti,
                    sub: parsedToken.sub
                }
                commit("user_logged", userInfo)
                return { autenticated: true }
            } catch (error) {
                return { autenticated: false }
            }
        }
    }
}