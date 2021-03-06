import Axios from 'axios'
const RESOURCE_NAME = '/Sales'
export default {
  getAll () {
    return Axios.get(RESOURCE_NAME)
  },
  getQuarters () {
    return Axios.get(`${RESOURCE_NAME}/quarters`)
  },
  get (id) {
    return Axios.get(`${RESOURCE_NAME}/${id}`)
  },
  create (data) {
    return Axios.post(RESOURCE_NAME, data)
  },
  update (id, data) {
    return Axios.put(`${RESOURCE_NAME}/${id}`, data)
  },
  delete (id) {
    return Axios.delete(`${RESOURCE_NAME}/${id}`)
  }
}
