import Axios from 'axios'
const RESOURCE_NAME = '/Report/finance'
export default {

  getFinReport () {
    return Axios.get(RESOURCE_NAME)
  }
}
