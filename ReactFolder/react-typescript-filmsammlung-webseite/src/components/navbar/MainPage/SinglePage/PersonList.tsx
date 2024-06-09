import './SinglePage.css';
import img from "./../../../../Images/PlaceHolder.jpg"
import {IPersonList} from '../../../../Interfaces'

const PersonList = (props: IPersonList) => {
    return(
        <>
        <div className="personList">
        <form>
            <div className='mainDiv'>
                <div>
                    <img className='images' src={img} alt="" />
                </div>
                <div >
                    <div>
                    <label>{props.Vorname}</label>
                    <label>{props.Nachname}</label>
                    </div>
                    <div>
                    <label>{props.Synopsis}</label>
                    <label>Film</label>
                    </div>
                </div>
            </div>
       </form>
        </div>

        </>

    );

}
export default PersonList;