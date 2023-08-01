class RestaurantReview extends React.Component {
   ////
   
   
   
   ////
        return (
            <div className="row">
                <div className="col-md-9">
                    <fieldset>
                        <legend>{this.state.name}</legend>
                        <Address address={this.state.address} onAddressChange={handleAddressChange} />
                        <div className="row form-group">
                            <div className="col-md-2 label-align">
                                <label htmlFor="txtSummary">Summary:</label>
                            </div>
                            <div className="col-md-10">
                                <textarea id="txtSummary" className="form-control" rows="4" value={} onChange={}></textarea>
                            </div>

                        </div>
                        <div className="row form-group">
                            <div className="col-md-2 label-align">
                                <label htmlFor="txtRating">Rating:</label>
                            </div>
                            <div className="col-md-10">
                                <select id="drpRating" className="form-control" value={} onChange={}>
                                    <option key="1" value="1">1</option>
                                    <option key="2" value="2">2</option>
                                    <option key="3" value="3">3</option>
                                    <option key="4" value="4">4</option>
                                    <option key="5" value="5">5</option>
                                </select>
                            </div>
                        </div>
                        <div className="row form-group">
                            <div className="col-md-2 label-align">
                                <button className="btn btn-primary" type="button" onClick={}>Save</button>
                            </div>
                            <div className="col-md-10" id="divConfirmation">
                                <span className="form-control alert-success" style={}>Update saved</span>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        );
    }
}