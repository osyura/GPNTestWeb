import Axios from 'axios'
const RESOURCE_NAME = '/Report'
export default {

  getFinReport (repname, repquarter, repdep) {
    return Axios.get(`${RESOURCE_NAME}/finance?name=${repname}&quarter=${repquarter}&department=${repdep}`)
  }
}
