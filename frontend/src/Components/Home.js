import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import Project from './LandingPage';
import ProjectTable from './ProjectTable';
import 'bootstrap/dist/css/bootstrap.css';
import TaskTable from './TaskTable';
import Topbar from './Topbar';
import { Navbar,NavLink,NavItem,Nav } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import LandingPage from './LandingPage';
import NavigateTo from './NavigateTo'
function Home() {
    
    return (
        <div>
          <div>
       <NavigateTo/>
        <LandingPage/>

    </div>



        </div>
    );

}
export default Home;