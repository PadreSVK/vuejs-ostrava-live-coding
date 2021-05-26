

import { extend, localize, ValidationObserver, ValidationProvider } from 'vee-validate'

import * as rules from 'vee-validate/dist/rules'
import en from 'vee-validate/dist/locale/en.json'
import cs from 'vee-validate/dist/locale/cs.json'
import { VTextFieldValidateable } from "@/components/Validateable";

export default {
    apply(Vue: any) {

        Object.keys(rules).forEach((rule) => {
            extend(rule, (rules as any)[rule]);
        });

        extend('password', {
            validate: value => {
                return value?.length >= 6;
            },
            message: '{_field_} must be more than 6 characters'
        });

        extend('confirmation', {
            params: ['target'],
            validate(value, { target }: any) {
                return value === target;
            },
            message: '{_field_} does not match'
        });

        localize('cs', cs);
        localize('en', en);

        Vue.component('ValidationObserver', ValidationObserver);
        Vue.component('ValidationProvider', ValidationProvider);
        
        Vue.component('v-text-field-validateable', VTextFieldValidateable);

    }
}